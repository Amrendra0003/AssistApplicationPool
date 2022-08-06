using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;
using HealthWare.ActiveASSIST.Entities.Mappings;
using HealthWare.ActiveASSIST.Entities.Master;
using HealthWare.ActiveASSIST.Repositories.Base.Connection;
using Healthware.Core.Base;
using Healthware.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthWare.ActiveASSIST.Repositories
{
    public interface IAssessmentRepository
    {
        Task<long> CreateAssessment(Assessment assessment);
        IEnumerable<Assessment> GetAssessmentsByUserId(long createdById, string partialName);
        Task<Entities.Assessment> GetAssessmentById(long assessmentId);
        Task<Tuple<List<DynamicScreens>, List<string>>> GetDynamicScreens(long tenantId);
        Task<bool> UpdateAssessmentStatus(Assessment assessment, string assessmentStatus);
        Task<bool> Delete(Assessment assessment);
        IEnumerable<DashboardAssessment> GetAssessmentListForDashboard(int userId, string searchText, long tenantId);
        IEnumerable<AssessmentInPatientDashboard> GetAssessmentListForPatientDashboard(int userId, string searchText, long tenantId);
        Task<List<long>> GetDynamicScreenIdList();
        Task<List<long>> GetTenantIdList();
        Task<bool> UpdateAssessmentIsEvaluated(Assessment assessment);
        Task<string> GetUserRoleOfTheAssessment(long assessmentId);
        Task<List<FacilityMapping>> GetUserIds(long Id);
    }
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly IUnitOfWork<PatientDbContext> _unitOfWork;
        private readonly PatientDbContext _context;
        public AssessmentRepository(IUnitOfWork<PatientDbContext> unitOfWork, PatientDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<long> CreateAssessment(Assessment assessment)
        {
            _unitOfWork.Attach(assessment.AssessmentStatusMaster);
            await _unitOfWork.AddAsync(assessment);
            await _unitOfWork.CommitAsync();
            return assessment.Id;
        }

        public IEnumerable<Assessment> GetAssessmentsByUserId(long createdById, string partialName)
        {
            var assessmentList = from sub in
                    (from p in _unitOfWork.GetEntities<BasicInfo>()
                     join a in _unitOfWork.GetEntities<Assessment>()
                  on p.Assessment.Id equals a.Id
                     where a.CreatedBy == createdById && a.IsActive == true
                     select new
                     {
                         AssessmentId = p.Assessment.Id,
                         Patient = p.Id,
                         AssessmentStatus = a.AssessmentStatusMaster,
                         IsActive = p.Assessment.IsActive,
                         CreatedBy = p.Assessment.CreatedBy,
                         createdDate = p.Assessment.CreatedDate,
                         FilterName = p.FirstName + ' ' + p.LastName + ' ' + p.Assessment.Id + ' ' + p.EmailAddress + ' ' +
                             p.CountyCode + p.CellNumber
                     })
                                 where sub.FilterName.Contains(partialName)
                                 select new Assessment()
                                 {
                                     Id = sub.AssessmentId,
                                     AssessmentStatusMaster = sub.AssessmentStatus,
                                     IsActive = sub.IsActive,
                                     CreatedBy = sub.CreatedBy,
                                     CreatedDate = sub.createdDate
                                 };

            var result = assessmentList.Select(a => new Assessment()
            {
                Id = a.Id,
                AssessmentStatusMaster = a.AssessmentStatusMaster,
                IsActive = a.IsActive,
                CreatedBy = a.CreatedBy,
                CreatedDate = a.CreatedDate
            }).ToList();
            return result;
        }

        public async Task<Assessment> GetAssessmentById(long assessmentId)
        {
            var assessment = await _unitOfWork.GetEntityAsync<Assessment>(y => y.Id == assessmentId);
            return assessment;
        }

        public async Task<Tuple<List<DynamicScreens>, List<string>>> GetDynamicScreens(long tenantId = 1)
        {
            var screenTenantMappings = await _unitOfWork.GetAllAsync<ScreenTenantMapping>(x => x.Tenant.Id == tenantId && x.RecordStatus == (long)Enums.RecordStatus.Active);
            var dynamicScreens = screenTenantMappings.OrderBy(x => x.Order).Select(x => x.Screen);
            var parentIdList = new List<string>();
            var dynamicScreensLinkedList = new LinkedList<DynamicScreens>(dynamicScreens);

            foreach (var item in dynamicScreensLinkedList)
            {
                var linkedListNode = dynamicScreensLinkedList.Find(item)?.Next;
                if (linkedListNode != null)
                    item.NextScreenId = linkedListNode?.Value.Id;
                var listNode = dynamicScreensLinkedList.Find(item)?.Previous;
                if (listNode != null)
                    item.PreviousScreenId = listNode?.Value.Id;

                item.Controls = item.Controls.OrderBy(x => x.Id)
                    .ThenBy(x => x.OrderId).ToList();
                foreach (var control in item.Controls)
                {
                    if (control.ParentQuestionId != null)
                    {
                        parentIdList.Add(control.ParentQuestionId.ToString());
                    }
                }
            }

            return Tuple.Create(dynamicScreensLinkedList.ToList(), parentIdList);
        }

        public async Task<List<long>> GetDynamicScreenIdList()
        {
            var dynamicScreens = await _unitOfWork.GetAllAsync<DynamicScreens>();
            var screenIdList = dynamicScreens.Select(x => x.Id).ToList();
            return screenIdList;
        }

        public async Task<List<long>> GetTenantIdList()
        {
            var tenantList = await _unitOfWork.GetAllAsync<TenantDetails>();
            var tenantIdList = tenantList.Select(x => x.Id).ToList();
            return tenantIdList;
        }

        public async Task<bool> UpdateAssessmentIsEvaluated(Assessment assessment)
        {
            assessment.IsEvaluated = true;
            _unitOfWork.Update(assessment);
            var isAssessmentUpdated  = await _unitOfWork.CommitAsync();
            return isAssessmentUpdated;

        }

        public async Task<string> GetUserRoleOfTheAssessment(long assessmentId)
        {
            var roleName = (from a in _unitOfWork.GetEntities<Assessment>()
                join b in _unitOfWork.GetEntities<UserHasRoles>() on a.CreatedBy equals b.User.Id
                join c in _unitOfWork.GetEntities<Role>() on b.Role.Id equals c.Id
                where a.Id == assessmentId
                select new
                {
                    RoleName = c.RoleName
                });
            var result = roleName.Select(a => a.RoleName).Single();

            return result;
        }

        public async Task<bool> UpdateAssessmentStatus(Assessment assessment, string assessmentStatus)
        {
            long assessmentStatusId = assessmentStatus switch
            {
                AssessmentStatus.Incomplete => (long)Enums.AssessmentStatus.Incomplete,
                AssessmentStatus.DocumentationIncomplete => (long)Enums.AssessmentStatus.DocumentationIncomplete,
                AssessmentStatus.Pending => (long)Enums.AssessmentStatus.VerificationPending,
                AssessmentStatus.Completed => (long)Enums.AssessmentStatus.Completed,
                _ => default
            };
            assessment.AssessmentStatusMaster = new AssessmentStatusMaster() { Id = assessmentStatusId };
            _unitOfWork.Update(assessment);
            var isAssessmentUpdated = await _unitOfWork.CommitAsync();
            return isAssessmentUpdated;
        }

        public async Task<bool> Delete(Assessment assessment)
        {
            _unitOfWork.Update(assessment);
            var isAssessmentDeleted = await _unitOfWork.CommitAsync();
            return isAssessmentDeleted;
        }
        public IEnumerable<DashboardAssessment> GetAssessmentListForDashboard(int userId, string searchText, long tenantId)
        {
            var assessments = _context.DashboardAssessment.FromSqlRaw($"{Constants.ExecuteStoredProcedure} {Constants.UspGetAssessmentDashboardDetails}  {Constants.UserIdParameter} = '{userId}',{Constants.PartialNameParameter} ='{searchText}', {Constants.TenantIdParameter} = '{tenantId}'").ToList();
            return assessments;
        }
        public async Task<List<FacilityMapping>> GetUserIds(long Id)
        {
            var document = await _unitOfWork.GetAllAsync<FacilityMapping>(x => x.UserId == Id);
            List<FacilityMapping> list1 = new List<FacilityMapping>();
            if(document.ToList().Count != 0)
            {
                foreach (var documentItem in document)
                {
                    var doc1 = await _unitOfWork.GetAllAsync<FacilityMapping>(x => x.FacilityId == documentItem.FacilityId);
                    var doc = doc1.ToList();
                    if (list1.Count == 0)
                    {
                        if (doc.Count != 0)
                        {
                            list1.AddRange(doc);
                            continue;
                        }
                    }
                    if (list1.Count != 0)
                    {
                        foreach (var item in list1)
                        {
                            if (doc.Count != 0)
                            {
                                foreach (var item1 in doc)
                                {
                                    if (item.UserId == item1.UserId)
                                    {
                                        doc.Remove(item1);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (doc.Count != 0)
                        list1.AddRange(doc);
                }
            }
            return list1;
        }
        public IEnumerable<AssessmentInPatientDashboard> GetAssessmentListForPatientDashboard(int userId, string searchText, long tenantId)
        {
            var assessments = _context.AssessmentInPatientDashboard.FromSqlRaw($"{Constants.ExecuteStoredProcedure} {Constants.UspGetPatientDashboardDetails} {Constants.UserIdParameter} = '{userId}', {Constants.PartialNameParameter} ='{searchText}', {Constants.TenantIdParameter} = '{tenantId}'").ToList();
            return assessments;
        }
    }
}

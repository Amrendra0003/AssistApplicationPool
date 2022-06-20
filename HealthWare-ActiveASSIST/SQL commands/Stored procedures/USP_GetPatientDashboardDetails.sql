USE [ActiveASSIST_QA_Common3]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetPatientDashboardDetails]    Script Date: 3/16/2022 8:34:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_GetPatientDashboardDetails] @UserId bigint, @PartialName nvarchar(50), @TenantId bigint
AS
select p.FirstName+' '+p.LastName as FullName,c.CountyCode, c.Cell, p.Gender as Gender,DATEDIFF(YEAR,p.DateOfBirth,CURRENT_TIMESTAMP) as Age, A.Id as AssessmentId,sm.AssessmentStatus as AssessmentStatus,
STRING_AGG( pr.Name, ', ') as Programs,P.Id as PatientId,'' as ProfileImageData,u.FirstName +' '+u.LastName as SubmittedByName,FORMAT (A.CreatedDate, 'MM/dd/yyyy hh:mm:ss tt') as SubmittedOn,
A.CreatedDate as CreatedDate, '' as HospitalName,p.CellNumber as CellNumber,p.CountyCode as CountryCode, p.EmailAddress as EmailAddress,
c.City as City, c.State as State, CASE a.AssessmentStatusMasterId
WHEN 1 THEN CAST(1 AS BIT)
ELSE CAST(0 AS BIT)
END as IsEditable, CASE a.AssessmentStatusMasterId
WHEN 1 THEN 'Yet To Sumbit'
ELSE 'Under Review'
END as StatusDisplayName
from
Assessment A
inner join BasicInfo p on A.Id = p.AssessmentId
	
inner join ContactDetails c on p.HomeContactId = c.Id
inner join AssessmentStatusMaster sm on A.AssessmentStatusMasterId = sm.Id

inner join PatientProgramMapping pp on A.Id = pp.AssessmentId
inner join Program pr on pp.ProgramId=pr.Id and pp.IsEvaluated = A.IsEvaluated
inner join MainUser u on A.CreatedBy = u.Id
where a.CreatedBy = @UserId and A.IsActive=1 and u.TenantId = @TenantId and UPPER(cast(p.AssessmentId as Varchar)+' '+p.FirstName+' '+p.LastName+' '+p.EmailAddress+' '+p.CountyCode+p.CellNumber) like upper('%'+@PartialName+'%')

group by A.Id, P.Id ,sm.AssessmentStatus ,p.FirstName+' '+p.LastName, p.EmailAddress ,p.CountyCode,
p.Gender, p.DateOfBirth, c.City, c.CountyCode, c.Cell ,C.State, A.CreatedDate,u.FirstName,u.LastName,p.CellNumber, A.AssessmentStatusMasterId
order by A.CreatedDate desc

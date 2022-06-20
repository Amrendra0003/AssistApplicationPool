USE [ActiveASSIST_QA_Common3]
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAssessmentDashboardDetails]    Script Date: 3/16/2022 8:36:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Inital Version 12/20/21 Stored Procedure to list of assessment details for the advocate dashboard

ALTER PROCEDURE [dbo].[USP_GetAssessmentDashboardDetails] @UserId bigint, @PartialName nvarchar(50), @TenantId bigint
AS
select A.Id as AssessmentId,P.Id as AssessmentPatientId, sm.AssessmentStatus as AssessmentStatus, p.FirstName+' '+p.LastName as PatientName,p.EmailAddress as Email,
p.Gender as Gender, cast(DATEDIFF(YEAR,p.DateOfBirth,CURRENT_TIMESTAMP) as nvarchar) as Age, c.City as City, FORMAT (A.CreatedDate, 'MM/dd/yyyy hh:mm:ss tt') as SubmittedOn, 
A.CreatedDate as CreatedDate, STRING_AGG( pr.Name, ', ') as Programs,'' as PatientProfileImage, c.StateCode as StateCode, CASE a.AssessmentStatusMasterId
    WHEN 1 THEN CAST(1 AS BIT)
    ELSE CAST(0 AS BIT)
END as IsEditable
from 
Assessment A 
inner join BasicInfo p on A.Id = p.AssessmentId
inner join ContactDetails c on p.HomeContactId = c.Id
inner join AssessmentStatusMaster sm on A.AssessmentStatusMasterId = sm.Id
inner join PatientProgramMapping pp on A.Id = pp.AssessmentId and pp.IsEvaluated = A.IsEvaluated
inner join Program pr on pp.ProgramId=pr.Id 
inner join MainUser u on A.CreatedBy = u.Id
where A.IsActive=1 and u.TenantId = @TenantId and UPPER(cast(p.AssessmentId as Varchar)+' '+p.FirstName+' '+p.LastName) like upper('%'+@PartialName+'%')
group by  A.Id, P.Id ,sm.AssessmentStatus ,p.FirstName+' '+p.LastName, p.EmailAddress ,
p.Gender, p.DateOfBirth, c.City, c.StateCode , A.CreatedDate, A.AssessmentStatusMasterId;

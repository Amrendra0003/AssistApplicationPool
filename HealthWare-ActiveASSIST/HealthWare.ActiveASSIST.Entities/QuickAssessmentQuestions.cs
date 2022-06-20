using System.Collections.Generic;
using Healthware.Core.Entities;

namespace HealthWare.ActiveASSIST.Entities
{
    public class QuickAssessmentQuestions : BaseEntity
    {
        public FieldType FieldType { get; set; }
        public string ScreenHeaderPatientLabel { get; set; }
        public string ScreenHeaderOthersLabel { get; set; }
        public string PatientLabel { get; set; }
        public string OthersLabel { get; set; }
        public string TextBoxSubLabel { get; set; }
        public string UniqueKey { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public string Class { get; set; }
        public string ScreenId { get; set; }//
        public string OrderId { get; set; }
        public string Placeholder { get; set; }
        //remove public string ScreenMappingId { get; set; }//what?
        //public string QuestionId { get; set; }
        public bool Required { get; set; }// for radio buttons and dropdown
        public string CustomValidation { get; set; }
        public string AlertInfo { get; set; }
        public string MessageInfo { get; set; }
        public string ErrorMessageInfo { get; set; }
        public string MaximumDate { get; set; }//Why? -Only for DOB
        public bool IsInlineLabel { get; set; }//Can we directly use InlineLabel if it is not empty, is this property required?--discussed
        public string InlineLabel { get; set; }
        // remove public string HouseholdMembersValidationMessage { get; set; }//Can't these be used under validators? If these are specific to a screen, is it always needed?
        // remove public string MinorsMembersValidationMessage { get; set; }   //Can't these be used under validators? If these are specific to a screen, is it always needed?
        public string TermAndConditionsMessageLabel { get; set; }    //Can't these be used under validators? If these are specific to a screen, is it always needed?
        public string TermAndConditionPopupMessage { get; set; }     //Can't these be used under validators? If these are specific to a screen, is it always needed?
        //public List<object> CountyOptions { get; set; }//Can it be reused with options?
        //public List<SubQuestion> SubQuestion { get; set; }
        public List<Option> Options { get; set; }
        public List<Validators> Validators { get; set; }
        public long? ParentQuestionId { get; set; }
        //public Validators Validators { get; set; }//Can't we add the validation message here?
    }

}

using System.Collections.Generic;

namespace HealthWare.ActiveASSIST.DTOs
{
    public class QuickAssessmentQuestionsDto
    {
        public List<Screen> Screens { get; set; }
        public bool IsDynamic { get; set; }

        public class Screen
        {
            public string ScreenId { get; set; }
            public string LeftHeader { get; set; }
            public string LeftContent { get; set; }
            public long? NextScreenId { get; set; }
            public long? PreviousScreenId { get; set; }
            public List<Control> Controls { get; set; }
        }


        public class Control
        {
            public string Type { get; set; }
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
            public string QuestionId { get; set; }
            public bool Required { get; set; }// for radio buttons and dropdown
            public string CustomValidation { get; set; }
            public string AlertInfo { get; set; }
            public string MessageInfo { get; set; }
            public string ErrorMessageInfo { get; set; }
            public string MaximumDate { get; set; }//Why? -Only for DOB
            public bool IsInlineLabel { get; set; }//Can we directly use InlineLabel if it is not empty, is this property required?--discussed
            public string InlineLabel { get; set; }
            public string TermAndConditionsMessageLabel { get; set; }    //Can't these be used under validators? If these are specific to a screen, is it always needed?
            public string TermAndConditionPopupMessage { get; set; }     //Can't these be used under validators? If these are specific to a screen, is it always needed?
            //public List<object> CountyOptions { get; set; }//Can it be reused with options?
            public long? ParentQuestionId { get; set; }
            public List<Control> SubQuestion { get; set; }
            public List<Option> Options { get; set; }
            public Validators Validators { get; set; }//Can't we add the validation message here?
        }


        public class Option
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Order { get; set; }
            public string Value { get; set; }
        }


        public class Validators
        {
            public bool Required { get; set; }
            public int MinLength { get; set; }
            public int MaxLength { get; set; }
            public int? Max { get; set; }
            public int? Min { get; set; }
            public string Pattern { get; set; }
        }



    }
}

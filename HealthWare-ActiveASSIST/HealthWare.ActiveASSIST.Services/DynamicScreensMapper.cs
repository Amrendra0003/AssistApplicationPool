using System.Collections.Generic;
using System.Linq;
using HealthWare.ActiveASSIST.DTOs;
using HealthWare.ActiveASSIST.Entities;

namespace HealthWare.ActiveASSIST.Services
{
    public interface IDynamicScreensMapper
    {
        QuickAssessmentQuestionsDto MapFrom(DynamicScreenList dynamicScreenList);
    }
    public class DynamicScreensMapper : IDynamicScreensMapper
    {
        public QuickAssessmentQuestionsDto MapFrom(DynamicScreenList dynamicScreenList)
        {
            var quickAssessmentQuestions = new QuickAssessmentQuestionsDto
            {
                Screens = new List<QuickAssessmentQuestionsDto.Screen>()
            };
            foreach (var screen in dynamicScreenList.Screens)
            {
                var screenDto = new QuickAssessmentQuestionsDto.Screen
                {
                    Controls = new List<QuickAssessmentQuestionsDto.Control>(),
                    LeftContent = screen.LeftContent,
                    LeftHeader = screen.LeftHeader,
                    NextScreenId = screen.NextScreenId,
                    PreviousScreenId = screen.PreviousScreenId,
                    ScreenId = screen.Id.ToString()
                };
                //quickAssessmentQuestions.Screens.Add(screenDto);
                foreach (var control in screen.Controls)
                {
                    var controlDto = new QuickAssessmentQuestionsDto.Control
                    {
                        Type = control.FieldType.Type,
                        PatientLabel = control.PatientLabel,
                        OthersLabel = control.OthersLabel,
                        TextBoxSubLabel = control.TextBoxSubLabel,
                        UniqueKey = control.UniqueKey,
                        FieldName = control.FieldName,
                        Value = control.Value,
                        Class = control.Class,
                        ScreenId = control.ScreenId,
                        OrderId = control.OrderId,
                        Placeholder = control.Placeholder,
                        Required = control.Required,
                        CustomValidation = control.CustomValidation,
                        AlertInfo = control.AlertInfo,
                        MessageInfo = control.MessageInfo,
                        ErrorMessageInfo = control.ErrorMessageInfo,
                        MaximumDate = control.MaximumDate,
                        IsInlineLabel = control.IsInlineLabel,
                        InlineLabel = control.InlineLabel,
                        TermAndConditionsMessageLabel = control.TermAndConditionsMessageLabel,
                        TermAndConditionPopupMessage = control.TermAndConditionPopupMessage,
                        QuestionId = control.Id.ToString(),
                        ParentQuestionId = control.ParentQuestionId,
                        ScreenHeaderOthersLabel = control.ScreenHeaderOthersLabel,
                        ScreenHeaderPatientLabel = control.ScreenHeaderPatientLabel,
                        Options = new List<QuickAssessmentQuestionsDto.Option>()
                    };
                    foreach (var option in control.Options)
                    {
                        var optionDto = new QuickAssessmentQuestionsDto.Option
                        {
                            Name = option.Name,
                            Order = option.Order,
                            Value = option.Value,
                            Id = option.Id.ToString()
                        };
                        controlDto.Options.Add(optionDto);
                    }
                    var validator = control.Validators.FirstOrDefault();
                    var validatorDto = new QuickAssessmentQuestionsDto.Validators();
                    if (validator != null)
                    {
                        validatorDto.Required = validator.Required;
                        validatorDto.MinLength = validator.MinLength;
                        validatorDto.MaxLength = validator.MaxLength;
                        validatorDto.Max = validator.Max;
                        validatorDto.Min = validator.Min;
                        validatorDto.Pattern = validator.Pattern?.Type;
                    }
                    controlDto.Validators = validatorDto;
                    screenDto.Controls.Add(controlDto);
                }
                quickAssessmentQuestions.Screens.Add(screenDto);
            }
            return quickAssessmentQuestions;
        }
    }
}

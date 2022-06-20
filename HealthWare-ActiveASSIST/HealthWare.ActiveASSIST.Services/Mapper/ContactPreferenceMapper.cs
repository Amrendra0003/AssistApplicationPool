using HealthWare.ActiveASSIST.DTOs;

namespace HealthWare.ActiveASSIST.Services.Mapper
{
    public interface IContactPreferenceMapper
    {
        Entities.ContactPreference MapFrom(CreateContactPreference createContactPreferenceRequest);
        Entities.ContactPreference MapFrom(Entities.ContactPreference contactPreference, UpdateContactPreference updateContactPreferenceRequest);
    }
    public class ContactPreferenceMapper : IContactPreferenceMapper
    {
        //Insert Contact Preference
        public Entities.ContactPreference MapFrom(CreateContactPreference createContactPreferenceRequest)
        {
            var contactPreference = new Entities.ContactPreference()
            {
                ContactAddressId = createContactPreferenceRequest.ContactAddressId,
                ContactEmailId = createContactPreferenceRequest.ContactEmailId,
                ContactPhoneId = createContactPreferenceRequest.ContactPhoneId,
                TimeOfCalling = createContactPreferenceRequest.TimeOfCalling,
                ModeOfCommunication = createContactPreferenceRequest.ModeOfCommunication,
                AssessmentId = createContactPreferenceRequest.AssessmentId
            };
            return contactPreference;
        }

        //Update Contact Preference
        public Entities.ContactPreference MapFrom(Entities.ContactPreference contactPreference, UpdateContactPreference updateContactPreferenceRequest)
        {
            contactPreference.TimeOfCalling = updateContactPreferenceRequest.TimeOfCalling;
            contactPreference.ContactEmailId = updateContactPreferenceRequest.ContactEmailId;
            contactPreference.ContactAddressId = updateContactPreferenceRequest.ContactAddressId;
            contactPreference.ContactPhoneId = updateContactPreferenceRequest.ContactPhoneId;
            contactPreference.ContactEmailId = updateContactPreferenceRequest.ContactEmailId;
            contactPreference.ModeOfCommunication = updateContactPreferenceRequest.ModeOfCommunication;
            return contactPreference;
        }
    }
}

﻿using PharmacyRegistrationApi.Dtos;
using PharmacyRegistrationApi.Model;

namespace PharmacyRegistrationApi.Adapters
{
    public class RegistrationInPharmacyAdapter
    {
        public static RegistrationInPharmacy RegistrationDtoToRegistration(RegistrationInPharmacyDto dto)
        {
            return new RegistrationInPharmacy(dto.PharmacyId, dto.ApiKey, dto.Name, dto.Town);
        }

        public static RegistrationInPharmacyDto RegistrationToRegistrationDto(RegistrationInPharmacy registration)
        {
           return new RegistrationInPharmacyDto(registration.PharmacyId, registration.ApiKey,registration.Name,registration.Town);
        }
    }
}

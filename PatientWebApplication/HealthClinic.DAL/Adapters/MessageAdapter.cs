﻿using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.ActionsAndBenefits;


namespace HealthClinic.CL.Adapters
{
    public class MessageAdapter
    {
        public static Message MessageDTOtoMessage(MessageDto dto)
        {
            return new Message(dto.Text, dto.TimeStamp, false, dto.PharmacyName);
        }

        public MessageDto MessageToMessageDTO(Message message)
        {
            return new MessageDto(message.Text, message.TimeStamp, message.PharmacyName);
        }
    }
}
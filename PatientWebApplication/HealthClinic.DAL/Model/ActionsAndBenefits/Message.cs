﻿using HealthClinic.CL.Model.Patient;
using System;


namespace HealthClinic.CL.Model.ActionsAndBenefits
{
    public class Message : Entity
    {
        public string Text { get; set; }

        public DateTime TimeStamp { get; set; }

        public string DateStamp { get; set; }

        public bool IsRemoved { get; set; }

        public string PharmacyName { get; set; }

        public string DateAction { get; set; }


        public Message() : base()
        {
        }

        public Message(int id, string text, string datestamp, DateTime timestamp, bool isremoved, string pharmacyname, string dateaction) : base(id)
        {
            Text = text;
            TimeStamp = timestamp;
            IsRemoved = isremoved;
            PharmacyName = pharmacyname;
            DateAction = dateaction;
            DateStamp = datestamp;
        }

        public Message(string text, string datestamp, DateTime timestamp, bool isremoved, string pharmacyname, string dateaction)
        {
            Text = text;
            TimeStamp = timestamp;
            IsRemoved = isremoved;
            PharmacyName = pharmacyname;
            DateAction = dateaction;
            DateStamp = datestamp;
        }

        public override string ToString()
        {
            return Text + " sent at " + TimeStamp.ToString();
        }
    }
}
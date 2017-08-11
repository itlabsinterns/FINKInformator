using ItLabs.FinkInformator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class ProgramsResponse : ResponseBase
    {
        //property containing all Program names
        public List<string> Programs;

        //Class constructor, setting Programs property to null
        public ProgramsResponse() : base()
        {
            this.Programs = null;
            GetAllPrograms();
        }

        //Method setting Programs property
        private void GetAllPrograms()
        {
            SchoolContext schoolContext = new SchoolContext();

            this.Programs = (from p in schoolContext.Programs
                              select p.ProgramName)
                              .ToList();
                       

            if (Programs == null || Programs.Count==0)
            {
                this.Errors.Add("No Result!");
                this.IsSuccessful = false;
            }
        }


    }
}
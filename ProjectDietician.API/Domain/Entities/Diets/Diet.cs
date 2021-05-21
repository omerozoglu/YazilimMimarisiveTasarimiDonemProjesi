using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities.Diets {
    public class Diet : EntityBase {

        public DietMethod DietMethod { get; set; }

        public List<Food> DietContentList { get; set; }

        //* Başlangıç tarihi şuandan daha önce bir tarihe atanamaz
        public DateTime StartDate {
            get { return this.StartDate; }
            set {
                if (value < DateTime.UtcNow) this.StartDate = DateTime.UtcNow;
                else this.StartDate = value;
            }
        }
        //* Bitiş tarihi Başlangıç tarihinden daha önce bir tarihe atanamaz
        public DateTime EndDate {
            get { return this.EndDate; }
            set {
                if (value < this.StartDate) this.EndDate = this.StartDate;
                else this.EndDate = value;
            }
        }

    }
}
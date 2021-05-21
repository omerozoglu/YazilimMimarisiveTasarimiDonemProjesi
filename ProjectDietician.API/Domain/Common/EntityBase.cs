using System;

namespace Domain.Common {

    /*
     *  EntityBase sınıfı tüm entitylerin kalıtım alması gereken temel bir sınıftır.
     */
    public class EntityBase {

        //*  string Id: Varlık kimliği.
        public string Id { get; protected set; }

        //*  string CreatedBy: Oluşturucu varlığın kimliği.
        public string CreatedBy { get; set; }

        //*  DateTime CreatedDate: Varlığın oluşturulma tarihi.
        public DateTime? CreatedDate { get; set; }

        //*   string LastModifiedBy: Düzenleyici varlığın kimliği
        public string LastModifiedBy { get; set; }

        //*  DateTime? LastModifiedDate: Varlığın düzenleme tarihi
        public DateTime? LastModifiedDate { get; set; }
    }
}
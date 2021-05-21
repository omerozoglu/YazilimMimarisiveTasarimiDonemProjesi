using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities.Diets {
    public class Food : EntityBase {

        //*string Name: Gıdanın Adı Örnek Sebze, meyve, tahıl,..vb
        public string Name { get; set; }

        //* Hastalık ve diet yöntemi adları sadece string olarak tutulacak
        public List<string> Tag { get; set; }
    }
}
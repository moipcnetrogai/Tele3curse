//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tele3.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tele3_Numbers
    {
        public int id { get; set; }
        public string number { get; set; }
        public string password { get; set; }
        public int minutes { get; set; }
        public System.DateTime nextpayment { get; set; }
        public bool IsActive { get; set; }
        public int Balance { get; set; }
        public int id_client { get; set; }
        public Nullable<int> id_tarif { get; set; }
        public Nullable<bool> password_set { get; set; }
    
        public virtual Tele3_Clients Tele3_Clients { get; set; }
        public virtual Tele3_Tarifs Tele3_Tarifs { get; set; }
    }
}

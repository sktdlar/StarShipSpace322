//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StarShip.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight_Passanger
    {
        public int id { get; set; }
        public Nullable<int> idPassanger { get; set; }
        public Nullable<int> idFlight { get; set; }
    
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}

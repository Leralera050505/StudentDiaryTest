//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentDiary.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class TimeTable
    {
        public int IdTimeTable { get; set; }
        public int IdLesson { get; set; }
        public System.TimeSpan TimeLesson { get; set; }
        public System.DateTime DateLesson { get; set; }
        public int IdWorker { get; set; }
        public int IdGroup { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Worker Worker { get; set; }
    }
}

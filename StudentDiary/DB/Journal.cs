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
    
    public partial class Journal
    {
        public int IdJournal { get; set; }
        public int IdLesson { get; set; }
        public int IdGrade { get; set; }
        public int IdStudent { get; set; }
    
        public virtual Grade Grade { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual Student Student { get; set; }
    }
}

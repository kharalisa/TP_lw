using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2MVC.Models
{
    public class StudentDbWork
    {
        [DisplayName("Идентификатор")]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("ФИО студента")]
        public string StudentName { get; set; }

        [DisplayName("Группа")]
        public string GroupName { get; set; }

        [DisplayName("Тема проекта")]
        [DataType(DataType.MultilineText)]
        public string ProjectTopic { get; set; }

        [DisplayName("Дата сдачи")]
        public DateTime SubmissionDate { get; set; }

        [DisplayName("Оценка")]
        public decimal Score { get; set; }

        [DisplayName("Есть защита")]
        public bool IsDefended { get; set; }

    }
}
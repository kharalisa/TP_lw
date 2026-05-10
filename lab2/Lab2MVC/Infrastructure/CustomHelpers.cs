using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using Lab2MVC.Models;

namespace Lab2MVC.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString RenderWorksTable(this HtmlHelper html, List<StudentDbWork> works, string title)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<h2>" + title + "</h2>");

            if (works.Count == 0)
            {
                result.Append("<p>Пока нет введённых данных.</p>");
            }
            else
            {
                result.Append("<table border='1'>");
                result.Append("<tr>");
                result.Append("<th>Идентификатор</th>");
                result.Append("<th>ФИО студента</th>");
                result.Append("<th>Группа</th>");
                result.Append("<th>Тема проекта</th>");
                result.Append("<th>Дата сдачи</th>");
                result.Append("<th>Оценка</th>");
                result.Append("<th>Есть защита</th>");
                result.Append("</tr>");

                for (int i = 0; i < works.Count; i++)
                {
                    result.Append("<tr>");
                    result.Append("<td>" + works[i].Id + "</td>");
                    result.Append("<td>" + works[i].StudentName + "</td>");
                    result.Append("<td>" + works[i].GroupName + "</td>");
                    result.Append("<td>" + works[i].ProjectTopic + "</td>");
                    result.Append("<td>" + works[i].SubmissionDate + "</td>");
                    result.Append("<td>" + works[i].Score + "</td>");
                    result.Append("<td>" + works[i].IsDefended + "</td>");
                    result.Append("</tr>");
                }

                result.Append("</table>");
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}
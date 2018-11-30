using Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardCodeData
{
    public class HardCodeBlog
    {
        private List<BlogItem> articles;
        public BlogItemContainer blogItemContainer;
        public HardCodeBlog()
        {
            articles = new List<BlogItem>();
            articles.Add(new BlogItem { Id = 1 ,});
            blogItemContainer = new BlogItemContainer(articles);
        }
        public HardCodeBlog(string[] paths)
        {
            articles = new List<BlogItem>();
            int i = 0;
            foreach (string path in paths)
            {

                articles.Add(new BlogItem { Id = i, Name = GetArticleName(i), Path = paths[i], PublishDate = GetDate(i),Type=GetArticleType(path),Short=GetShort(i) });
                i++;
            }
            blogItemContainer = new BlogItemContainer(articles);
        }
        private string GetArticleType(string s)
        {

            int ind = s.Length - 6;
            string z = s[ind].ToString();
 
            switch (z)
            {
                case "S":return "Общие";
                case "M": return "Разное";
                case "L": return "Учебные";
            }
            return "Общие";
        }
        private string GetArticleName(int id)
        {
          
            switch (id)
            {
                case 0: return "Поведение";
                case 1: return "Структура бизнес-плана";
                case 2: return "Зачем нужен бизнес-план";
                case 3: return "О проекте";
                case 4: return "Поиск информации";
                case 5: return "О деньгах";
                case 6: return "Типы преподавателей";
                case 7: return "Как выбрать руководителя";
  
            }
            return "Неизвестно";
        }
        private string GetShort(int id)
        {

            switch (id)
            {
                case 0: return "Никогда не опаздывайте на консультации со своим научным руководителем, особенно на те, которые он назначил лично. В случае, когда вы уверены, что не сможете прийти на консультацию или опоздаете, необходимо заранее предупредить об этом научного руководителя.";
                case 1: return "Независимо от цели, для которой составляется бизнес-план, в нем в обязательном порядке должны быть следующие основные разделы:";
                case 2: return "Понятие бизнес-план произошло от англ. словосочетания «business plan», что дословно означает «план предпринимательской деятельности».";
                case 3: return "Актуальность проекта. Сложившаяся в настоящий момент времени система высшего образования в нашей стране оставляет желать лучшего.";
                case 4: return "Уважаемые студенты! Все мы прекрасно знаем, как сегодня пишутся курсовые и дипломные работы, даже самые качественные. Весь необходимый материал собирается в Интернете, который просто разрывается от потока контента.";
                case 5: return "Как-то раз во время лекции преподаватель спросил у студентов:";
                case 6: return "Коммунист-бюрократ. Пожалуй, худшее, с чем может столкнуться студент. Мало того, что такой тип преподавателей придирается к каждой мелочи (недостающая точка, пробел, округление до десятых, а не до сотых и т.д.), они еще и нагрузят студента дополнительной работой (изучить материал, каким-то образом связанный с темой научной работы, и высказать свою точку зрения по этому поводу). Не выполнил задание – остался и вовсе без помощи в написании!";
                case 7: return "Определиться с целью.Сначала определите для себя, хотите ли вы просто написать, защитить диплом и успешно забыть об этом или сделать реально сильную работу, которая послужит ступенькой для научной деятельности. Если вы выбрали первый вариант, то дальше следует определить, кто будет заниматься этой муторной и нудной работой – только вы, только исполнитель(писатель научных работ) или же вы совместно с помощником(тем же исполнителем). Лучшим вариантом, конечно, будет третий.Так вы сэкономите очень много времени и сумеете разобраться в теме, что очень важно, ведь защищать диплом за вас никто не сможет!Во втором случае, естественно, писать работу предстоит самостоятельно.";

            }
            return "Неизвестно";
        }
        private DateTime GetDate(int id)
        {

            switch (id)
            {
                case 0: return new DateTime(2018,11,05);
                case 1: return new DateTime(2018, 10, 25);
                case 2: return new DateTime(2018, 10, 22);
                case 3: return new DateTime(2018, 10, 11);
                case 4: return new DateTime(2018, 10, 02);
                case 5: return new DateTime(2018, 09, 29);
                case 6: return new DateTime(2018, 09, 21);
                case 7: return new DateTime(2018, 09, 09);

            }
            return DateTime.Now;
        }
    }
}

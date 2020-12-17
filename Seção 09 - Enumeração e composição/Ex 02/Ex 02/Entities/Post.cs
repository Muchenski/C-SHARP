using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_02.Entities {
    class Post {
        public DateTime Moment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }

        List<Comment> Comments = new List<Comment>();

        public Post() {

        }

        public Post(DateTime moment, string title, string content, int like) {
            Moment = moment;
            Title = title;
            Content = content;
            Like = like;
        }

        public void RemoveComment(Comment comment) {
            Comments.Remove(comment);
        }

        public void AddComment(Comment comment) {
            Comments.Add(comment);
        }

        public override string ToString() {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Title);
            sb.AppendLine($"{Like} Likes - {Moment}");
            sb.AppendLine(Content);
            sb.AppendLine("Comments: ");

            foreach(Comment c in Comments) {
                sb.AppendLine(c.text);
            }

            return sb.ToString();
        }
    }
}

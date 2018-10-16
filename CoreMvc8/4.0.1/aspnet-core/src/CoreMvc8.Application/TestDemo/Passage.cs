using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMvc8.TestDemo
{
    public class Passage
    {
        //文章编号
        [Key]
        public long PassageId { get; set; }

        //标题
        public string Title { get; set; }

        //描述
        public string Description { get; set; }

        //内容
        public string Content { get; set; }

        //发布时间
        public DateTime PublishTime { get; set; }

        //最后编辑时间
        public DateTime LastEditTime { get; set; }

        //文章分类（使用技术等）
        public virtual IList<PassageCategory> PassageCategories { get; set; }
    }
}

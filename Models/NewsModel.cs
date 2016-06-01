﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTL.Models
{
	public class NewsModel
	{
		public int Id { get; set; }

		public int NId { get; set; }
		public string Title { get; set; }

		public string Msg { get; set; }

		public DateTime SubDateTime { get; set; }

		public string Author { get; set; }

		public string ImagePath { get; set; }


	}
}

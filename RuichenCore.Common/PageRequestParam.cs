﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RuichenCore.Common
{
    [Serializable]
    public class PageRequestParam:RequestParam
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public interface IFeedbackRepository
    {
        Feedback AddFeedback(Feedback feedback);
    }
}

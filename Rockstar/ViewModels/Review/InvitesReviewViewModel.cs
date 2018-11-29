using System.Collections.Generic;
using Models;

namespace Rockstar.ViewModels.Review
{
    public class InvitesReviewViewModel
    {
        public List<Models.Review> Reviews { get; set; }
        public Models.Review NewReview { get; set; }
        public List<Models.Category> Categories { get; set; }
    }
}

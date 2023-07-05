using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.WinUI.Helpers
{
    public class AlertMessages
    {
        public const string RequiredField = "Required Field!";
        public const string CastNotEmptyField = "First and Last name reqiured!";
        public const string SuccessfulyAdded = "Successfuly Added!";
        public const string Delete = "Are you sure you want to delete selected item?";
        public const string Cancel = "Are you sure you want to cancel selected reservation?";
        public const string SuccessfulyCanceled = "Successfuly Canceled!";
        public const string AlreadyCanceled = "Reservation has been already canceled!";
        public const string OnlyNumbersAllowed = "Only numbers allowed!";
        public const string EmailFormat = "Email not in a right format!";
        public const string SeatsNotSelected = "Please select seats to make reservation, reservation failed!";
        public const string EndTimeNotValid = "End time must be larger than start time";
        public const string GenresNotValid = "Movie must contain at least one genre!";
        public const string ActorsNotValid = "Movie must contain at least one actor! Please add new ones by clicking button 'Add actors' and then deselect the ones you want to remove";
        public const string ProducersNotValid = "Movie must contain at least one producer! Please add new ones by clicking button 'Add producers' and then deselect the ones you want to remove";
        public const string WritersNotValid = "Movie must contain at least one writer! Please add new ones by clicking button 'Add writers' and then deselect the ones you want to remove";
        public const string DirectorsNotValid = "Movie must contain at least one director! Please add new ones by clicking button 'Add directors' and then deselect the ones you want to remove";
        public const string CantDeleteEmptyRow = "Can't delete an empty row";

    }
}

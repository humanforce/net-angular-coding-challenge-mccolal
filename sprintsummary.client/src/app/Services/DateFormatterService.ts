import { formatDate } from "@angular/common";


export const customDateFormatter = (date: Date) : string => {
  var dateStringSplit = date.toString().substring(0, 10).split('-');
  var dateStringFormatted = dateStringSplit[1] + '-' + dateStringSplit[2] + '-' + dateStringSplit[0];
  let formattedStartDate = formatDate(new Date(dateStringFormatted), 'yyyy-MM-dd', 'en');
  return formattedStartDate;
}

import { Component, Input, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PublicHoliday } from '../../models/public-holiday'
import { formatDate } from '@angular/common';
import { SprintDataModel } from '../../models/SprintModel';
import { customDateFormatter } from '../../Services/DateFormatterService'
import { RestApiService } from '../../Services/HTTPService';

@Component({
  selector: 'app-public-holiday',
  templateUrl: './public-holiday.component.html',
  styleUrl: './public-holiday.component.css'
})
export class PublicHolidayComponent {
  public publicHolidays: PublicHoliday[] | undefined;
  public loading: boolean = false;
  @Input() sprintInfo: SprintDataModel | undefined;
  constructor(public restAPI: RestApiService) { }

  ngOnChanges(changes: SimpleChanges) {
    this.fetchPublicHolidaysByDate(changes['sprintInfo'].currentValue.startDate,
      changes['sprintInfo'].currentValue.endDate)
  }

  fetchPublicHolidaysByDate(startDate: Date, endDate: Date) {
    this.publicHolidays = undefined;
    this.loading = true;

    let formattedStartDate = customDateFormatter(startDate);
    let formattedEndDate =  customDateFormatter(endDate);
    
    this.restAPI.getPublicHolidaysByDate(formattedStartDate, formattedEndDate).subscribe(
      (result) => {
        this.publicHolidays = result;
      },
      (error) => {
        console.error(error);
      }
    );
    this.loading = false;
  }

  getPublicHolidays() {
    this.publicHolidays = undefined;
    this.loading = true;
    this.restAPI.getPublicHolidays().subscribe(
      (result) => {
        this.publicHolidays = result;
      },
      (error) => {
        console.error(error);
      }
    );
    this.loading = false;
  }

}

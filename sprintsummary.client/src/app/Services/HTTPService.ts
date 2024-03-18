import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { PublicHoliday } from '../models/public-holiday';
import { CapacityStatisticsModel } from '../models/CapacityStatisticsModel';
import { Jira } from '../models/JiraModel';
import { SprintCapacityModel } from '../models/UserCapacityModel';
import { SprintDataModel } from '../models/SprintModel';

@Injectable({
  providedIn: 'root',
})
export class RestApiService {
  apiURL = 'https://localhost:4200';
  constructor(private http: HttpClient) { }

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  getPublicHolidaysByDate(startDate: string, endDate: string): Observable<PublicHoliday[]> {
    return this.http
      .get<PublicHoliday[]>(this.apiURL + '/publicholiday/' + startDate + '/' + endDate)
      .pipe(retry(1), catchError(this.handleError))
  }

  getPublicHolidays(): Observable<PublicHoliday[]> {
    return this.http
      .get<PublicHoliday[]>(this.apiURL + '/publicholiday/')
      .pipe(retry(1), catchError(this.handleError))
  }

  getSprintStatistics(sprintId: number, numberOfPreviousSprints: number): Observable<CapacityStatisticsModel> {
    return this.http
      .get<CapacityStatisticsModel>(this.apiURL + '/jira/' + sprintId + ' /' + numberOfPreviousSprints)
      .pipe(retry(1), catchError(this.handleError))
  }

  getJiraInfoBySprintId(sprintId: number): Observable<Jira[]> {
    return this.http
      .get<Jira[]>(this.apiURL + '/jira/' + sprintId)
      .pipe(retry(1), catchError(this.handleError))
  }

  getCapacityBySprintId(sprintId: number): Observable<SprintCapacityModel[]> {
    return this.http
      .get<SprintCapacityModel[]>(this.apiURL + '/sprintcapacity/' + sprintId)
      .pipe(retry(1), catchError(this.handleError))
  }

  getSprintClosestToDate(date: string): Observable<SprintDataModel> {
    return this.http
      .get<SprintDataModel>(this.apiURL + '/sprint/' + date + '/getdateinfo') 
      .pipe(retry(1), catchError(this.handleError))
  }

  getSprintById(sprintId: number): Observable<SprintDataModel> {
    return this.http
      .get<SprintDataModel>(this.apiURL + '/sprint/' + sprintId)
      .pipe(retry(1), catchError(this.handleError))
  }


  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}.  If you are starting the application, please wait for the server to become responsive.`;
    }
    //window.alert(errorMessage);
    console.log(errorMessage)
    return throwError(() => {
      return errorMessage;
    });
  }
}

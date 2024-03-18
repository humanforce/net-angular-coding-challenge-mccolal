import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SprintDataModel } from './models/SprintModel';
import { Subject } from 'rxjs';
import { RestApiService } from './Services/HTTPService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public sprintInfo: SprintDataModel = new SprintDataModel();
  eventsSubject: Subject<void> = new Subject<void>();

  constructor(public restApi: RestApiService) { }

  ngOnInit() {
    this.fetchSprintInfo();
  }

  fetchSprintInfo() {
    var now = formatDate(new Date(), 'yyyy-MM-dd', 'en');



    this.restApi.getSprintClosestToDate(now).subscribe(
      (result: SprintDataModel) => {
        //console.log(result)
        this.sprintInfo = result;        
      },
      (error: any) => {
        //console.log(error)
      }
    )
    
  }

  fetchSprintInfoByDate(date: Date) {

  }

  prevSprintHandler(event: any) {
    var prevSprintId = this.sprintInfo.id - 1;
    this.restApi.getSprintById(prevSprintId).subscribe(
      (result) => {
        this.sprintInfo = result;      
      },
      (error) => {
        //console.log(error)
      }
    )
  }
  nxtSprinthandler(event: any) {
    var nextSprintId = this.sprintInfo.id + 1;
    this.restApi.getSprintById(nextSprintId).subscribe(
      (result) => {
        this.sprintInfo = result;
      },
      (error) => {
        //console.log(error)
      }
    )
  }


  title = 'angularapp3.client';
}

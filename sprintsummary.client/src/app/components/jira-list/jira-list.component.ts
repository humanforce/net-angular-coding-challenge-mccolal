import { Component, Input, SimpleChanges } from '@angular/core';
import { SprintDataModel } from '../../models/SprintModel';
import { HttpClient } from '@angular/common/http';
import { Jira, JiraDataModel } from '../../models/JiraDataModel';
import { RestApiService } from '../../Services/HTTPService';

@Component({
  selector: 'app-jira-list',
  templateUrl: './jira-list.component.html',
  styleUrl: './jira-list.component.css'
})
export class JiraListComponent {
  public jiras: Jira[] | undefined;

  @Input() sprintInfo: SprintDataModel | undefined;

  constructor(public restApi: RestApiService) { }

  ngOnChanges(changes: SimpleChanges) {
    this.fetchJiraInfo(changes['sprintInfo'].currentValue.id)
  }

  fetchJiraInfo(sprintId: number) {
    this.jiras = undefined;
    this.restApi.getJiraInfoBySprintId(sprintId).subscribe(
      (result) => {
        this.jiras = result;
      },
      (error) => {

      }
    )
  }
}

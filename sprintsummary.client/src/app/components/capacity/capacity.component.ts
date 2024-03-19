import { Component, Input, SimpleChanges } from '@angular/core';
import { SprintDataModel } from '../../models/SprintModel';
import { SprintCapacityModel } from '../../models/UserCapacityModel';
import { HttpClient } from '@angular/common/http';
import { RestApiService } from '../../Services/HTTPService';

@Component({
  selector: 'app-capacity',
  templateUrl: './capacity.component.html',
  styleUrl: './capacity.component.css'
})
export class CapacityComponent {
  @Input() sprintInfo: SprintDataModel | undefined;
  public sprintCapacityList: SprintCapacityModel[] | undefined;
  constructor(public restApi: RestApiService) { }

  ngOnInit() {

  }

  ngOnChanges(changes: SimpleChanges) {
    this.fetchCapacityBySprintId(changes['sprintInfo'].currentValue.id)
  }

  fetchCapacityBySprintId(sprintId: number) {
    this.sprintCapacityList = undefined;
    this.restApi.getCapacityBySprintId(sprintId).subscribe(
      (result) => {
        this.sprintCapacityList = result;
      },
      (error) => {
        console.error(error);
      }
    );

  }


}

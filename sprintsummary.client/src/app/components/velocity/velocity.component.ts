import { Component, Input, SimpleChanges, input } from '@angular/core';
import { SprintDataModel } from '../../models/SprintModel';
import { CapacityStatisticsModel, SprintStatisticModel } from '../../models/CapacityStatisticsModel';
import { HttpClient } from '@angular/common/http';
import { RestApiService } from '../../Services/HTTPService';

@Component({
  selector: 'app-velocity',
  templateUrl: './velocity.component.html',
  styleUrl: './velocity.component.css'
})
export class VelocityComponent {
  @Input() sprintInfo: SprintDataModel | undefined;
  public capacityStatistics: CapacityStatisticsModel | undefined;
  public sprintStatistics: SprintStatisticModel[] | undefined;


  constructor(public restAPI: RestApiService) { }

  ngOnChanges(changes: SimpleChanges) {
    this.fetchSprintStatistics(changes['sprintInfo'].currentValue.id,3)
  }

  fetchSprintStatistics(sprintID: number, numberOfPreviousSprints: number) {
    this.capacityStatistics = undefined;
    this.sprintStatistics = undefined;
    this.restAPI.getSprintStatistics(sprintID,numberOfPreviousSprints).subscribe(
      (result) => {
        this.capacityStatistics = result;
        this.sprintStatistics = result.sprintStatistics;
        //console.log(this.sprintStatistics)
      },
      (error) => {
        console.error(error);
      }
    );
  }

}

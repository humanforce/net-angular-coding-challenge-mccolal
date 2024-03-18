import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { SprintDataModel } from '../../models/SprintModel';
import { customDateFormatter } from '../../Services/DateFormatterService';

@Component({
  selector: 'app-sprint-navigator',
  templateUrl: './sprint-navigator.component.html',
  styleUrl: './sprint-navigator.component.css'
})
export class SprintNavigatorComponent {
  @Output() prevSprint: EventEmitter<any> = new EventEmitter();
  @Output() nxtSprint: EventEmitter<any> = new EventEmitter();
  @Input() sprintInfo: SprintDataModel | undefined;
  public formattedStartDate: Date | undefined;
  public formattedEndDate: Date | undefined;

  ngOnChanges(changes: SimpleChanges) {

    this.formattedStartDate = new Date(customDateFormatter(changes['sprintInfo'].currentValue.startDate))
    this.formattedEndDate = new Date(customDateFormatter(changes['sprintInfo'].currentValue.endDate))
    
  }

  previousSprint() {
    this.prevSprint.emit(null);
  }
  nextSprint() {
    this.nxtSprint.emit(null);
  }
}

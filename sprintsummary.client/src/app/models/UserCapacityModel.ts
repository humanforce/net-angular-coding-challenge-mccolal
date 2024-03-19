import { JiraUserModel } from "./JiraUserModel";

export interface SprintCapacityModel {
  sprintId: number,
  capacity: number,
  user: JiraUserModel
}


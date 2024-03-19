export interface CapacityStatisticsModel {
  sprintID: number
  capacity: number
  sprintStatistics: SprintStatisticModel[]
}

export interface SprintStatisticModel {
  sprintId: number
  completedStoryPoints: number
}

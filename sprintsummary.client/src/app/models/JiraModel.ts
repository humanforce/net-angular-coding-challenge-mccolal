export interface JiraDataModel {
  jiras: Jira[]
  sprintStatistics: SprintStatistics
}

export interface Jira {
  expand: string
  id: string
  self: string
  key: string
  fields: Fields
}

export interface Fields {
  statuscategorychangedate: string
  issuetype: any
  timespent: any
  customfield_10030: any
  project: any
  customfield_10033: any
  fixVersions: any
  aggregatetimespent: any
  customfield_10034: any
  resolution: any
  customfield_10027: any
  customfield_10028: any
  customfield_10029: any
  resolutiondate: any
  workratio: number
  lastViewed: any
  watches: any
  created: string
  customfield_10020: Customfield10020[]
  customfield_10021: any
  customfield_10022: any
  priority: any
  customfield_10023: any
  customfield_10024: any
  customfield_10025: any
  labels: any
  customfield_10026: any
  storyPoints: number
  customfield_10017: any
  customfield_10018: any
  customfield_10019: any
  timeestimate: any
  aggregatetimeoriginalestimate: any
  versions: any
  issuelinks: any
  assignee: any
  updated: string
  status: any
  components: any
  timeoriginalestimate: any
  description: any
  customfield_10010: any
  customfield_10014: any
  customfield_10015: any
  customfield_10005: any
  customfield_10006: any
  security: any
  customfield_10007: any
  customfield_10008: any
  aggregatetimeestimate: any
  customfield_10009: any
  summary: any
  creator: any
  subtasks: any
  reporter: any
  aggregateprogress: any
  customfield_10001: any
  customfield_10002: any
  customfield_10003: any
  customfield_10004: any
  environment: any
  duedate: any
  progress: any
  votes: any
}

export interface Customfield10020 {
  id: number
  name: string
  state: string
  boardId: number
  goal: string
  startDate: string
  endDate: string
}

export interface SprintStatistics {
  sprintID: number
  capacity: number
  userStatistics: UserStatistic[]
}

export interface UserStatistic {
  user: number
  completedStoryPoints: number
}

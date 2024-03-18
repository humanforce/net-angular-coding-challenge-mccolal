export class SprintDataModel {
  public id: number;
  public self: string;
  public state: string;
  public name: string;
  public startDate: Date;
  public endDate: Date;
  public originBoardId: number;
  public goal: string; 


  /*constructor(id: number, self: string, state: string, name: string, startDate: Date, endDate: Date, originBoardId: number, goal: string) {
    this.id = id;
    this.self = self;
    this.state = state;
    this.name = name;
    this.startDate = startDate;
    this.endDate = endDate;
    this.originBoardId = originBoardId;
    this.goal = goal;
  }*/

  constructor(obj?: any) {
    this.id = 0;
    this.self = "";
    this.state = "";
    this.name = "";
    this.startDate = new Date("2000-01-01");
    this.endDate = new Date("2000-01-01");
    this.originBoardId = 0;
    this.goal = "";
    Object.assign(this, obj)
  }
}

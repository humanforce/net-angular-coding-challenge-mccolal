export interface JiraUserModel {
  id: string;
  name: string;
  location: {
    id: string,
    country: string,
    region: string
  }
}


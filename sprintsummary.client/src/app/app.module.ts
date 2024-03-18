import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicHolidayComponent } from './components/public-holiday/public-holiday.component';
import { SprintNavigatorComponent } from './components/sprint-navigator/sprint-navigator.component';
import { VelocityComponent } from './components/velocity/velocity.component';
import { JiraListComponent } from './components/jira-list/jira-list.component';
import { CapacityComponent } from './components/capacity/capacity.component';

@NgModule({
  declarations: [
    AppComponent,
    PublicHolidayComponent,
    SprintNavigatorComponent,
    VelocityComponent,
    JiraListComponent,
    CapacityComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

  
}

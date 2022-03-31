import { AppComponent } from './app.component';
import { StudentDetailsComponent } from './components/student-details/student-details.component';
import { StudentListComponent } from './components/layout/student-list/student-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { routeConstants } from './Constants/routes.constants';

const routes: Routes = [
  {
    path: routeConstants.studentList,
    component: StudentListComponent
  },
  {
     path: `${routeConstants.studentList}/:studentId`,
     component: StudentDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

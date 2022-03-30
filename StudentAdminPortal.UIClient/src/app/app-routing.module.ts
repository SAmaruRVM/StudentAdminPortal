import { StudentListComponent } from './components/layout/student-list/student-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { routeConstants } from './Constants/routes.constants';

const routes: Routes = [
  {
    path: routeConstants.index,
    component: StudentListComponent
  },
  {
    path: routeConstants.studentList,
    component: StudentListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

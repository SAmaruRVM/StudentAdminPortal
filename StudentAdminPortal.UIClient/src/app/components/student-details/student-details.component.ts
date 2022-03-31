import { routeConstants } from 'src/app/Constants/routes.constants';
import { ToastrService } from 'ngx-toastr';
import { StudentsService } from 'src/app/services/students.service';
import { Component, OnInit } from '@angular/core';
import { IStudent } from 'src/app/models/student.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html'
})
export class StudentDetailsComponent implements OnInit {
  routeConstants = routeConstants;
  student: IStudent;
  constructor
  (
    private readonly studentService: StudentsService,
    private readonly toastr: ToastrService,
    private readonly activatedRoute: ActivatedRoute
  )
    { }

  ngOnInit(): void {

      let studentId: string;
         this.activatedRoute.params.subscribe((parameters) => {
           studentId = parameters['studentId'];
         });

      this.retrieveStudentByTheirId(studentId);
  }

  retrieveStudentByTheirId(studentId: string): void
  {
    this.studentService
       .retrieveStudentByTheirId(studentId)
       .subscribe(student => {
         this.student = student;
       }, _ => {
           this.toastr.error('For some reason, we could not load the specified student.');
       })
  }

}

import { GendersService } from './../../services/genders.service';
import { routeConstants } from 'src/app/Constants/routes.constants';
import { ToastrService } from 'ngx-toastr';
import { StudentsService } from 'src/app/services/students.service';
import { Component, OnInit } from '@angular/core';
import { IStudent } from 'src/app/models/student.model';
import { ActivatedRoute, Router } from '@angular/router';
import { IGender } from 'src/app/models/gender.model';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
})
export class StudentDetailsComponent implements OnInit {
  routeConstants = routeConstants;
  student: IStudent;
  genders: IGender[];
  constructor(
    private readonly studentService: StudentsService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly genderService: GendersService,
    private readonly router: Router,
    public readonly toastr: ToastrService
  ) {}

  ngOnInit(): void {
    let studentId: string;
    this.activatedRoute.params.subscribe((parameters) => {
      studentId = parameters['studentId'];
    });

    this.retrieveStudentByTheirId(studentId);
    this.retrieveAllGenders();
  }

  retrieveAllGenders(): void {
    this.genderService.retrieveAll().subscribe(
      (genders) => {
        this.genders = genders;
      },
      (_) => {
        this.toastr.error(
          'For some reason, we could not load the gender list.'
        );
      }
    );
  }

  retrieveStudentByTheirId(studentId: string): void {
    this.studentService.retrieveStudentByTheirId(studentId).subscribe(
      (student) => {
        this.student = student;
      },
      (_) => {
        this.toastr.error(
          'For some reason, we could not load this specific student.'
        );
      }
    );
  }

  updateStudentDetails(): void {
    this.studentService.updateStudentDetails(this.student).subscribe(
      (success) => {
        this.toastr.success('Student was updated successfully');
      },
      (_) => {
        this.toastr.error(
          'For some reason, we could not update this specific student.'
        );
      }
    );
  }

  deleteStudent(): void {
     this.studentService.deleteStudentByTheirId(
       this.student.id
     )
     .subscribe((success) => {
      this.toastr.success('Student was deleted successfully');
      this.router.navigate(['students']);

     }, (_) => {
       this.toastr.error('For some reason, we could not delete this specific student');
     })
  }
}

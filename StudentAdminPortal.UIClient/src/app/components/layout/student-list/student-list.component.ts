import { IStudent } from './../../../models/student.model';
import { Component, OnInit, ViewChild } from '@angular/core';
import { StudentsService } from 'src/app/services/students.service';
import { ToastrService } from 'ngx-toastr';
import { MatTableDataSource } from '@angular/material/table';
import { nameof } from 'ts-simple-nameof';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css'],
})
export class StudentListComponent implements OnInit {
  students: IStudent[] = [];
  studentsTableColumns: string[] = [
    nameof<IStudent>((s) => s.firstName),
    nameof<IStudent>((s) => s.lastName),
    nameof<IStudent>((s) => s.dateOfBirth),
    nameof<IStudent>((s) => s.email),
    nameof<IStudent>((s) => s.mobile),
    nameof<IStudent>((s) => s.gender),
  ];

  @ViewChild(MatPaginator)
  matPaginator?: MatPaginator;

  @ViewChild(MatSort)
  matSort?: MatSort;

  dataSource: MatTableDataSource<IStudent> = new MatTableDataSource<IStudent>();

  constructor(
    private studentsService: StudentsService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.retrieveAllStudents();
  }

  private retrieveAllStudents(): void {
    this.studentsService.retrieveAllStudents().subscribe(
      (students) => {
        this.students = students;
        this.dataSource = new MatTableDataSource(students);

        if (this.matPaginator) {
          this.dataSource.paginator = this.matPaginator;
        }

        if (this.matSort) {
          this.dataSource.sort = this.matSort;
        }
      },
      (error) => {
        this.toastr.error('Api is not currently running.', 'Error');
      }
    );
  }
}

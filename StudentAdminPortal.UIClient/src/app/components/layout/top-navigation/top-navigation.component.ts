import { Component } from '@angular/core';
import { routeConstants } from 'src/app/Constants/routes.constants';

@Component({
  selector: 'app-top-navigation',
  templateUrl: './top-navigation.component.html',
  styleUrls: [
    './top-navigation.component.css'
  ]
})
export class TopNavigationComponent
{
    routeConstants = routeConstants;
}

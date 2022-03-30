import { IAddress } from './address.model';
import { IGender } from './gender.model';

export interface IStudent {
  id: string;
  firstName: string;
  lastName: string;
  dateOfBirth: string;
  email: string;
  mobile: string;
  avatarURL: string;
  gender: IGender;
  addresses: IAddress[];
}
  
import { TransactionalInformation } from './transactionalinformation.entity';
import { ApplicationMenu } from './application.entity';

export class User extends TransactionalInformation {
    public userID: number;
    public firstName: string;
    public lastName: string;
    public emailAddress: string;
    public addressLine1: string;
    public addressLine2: string;
    public city: string;     
    public state: string;
    public zipCode: string;
    public password: string;    
    public passwordConfirmation: string;
    public dateCreated: Date;
    public dateUpdated: Date;
    public menuItems: Array<ApplicationMenu>;
}


import { TransactionalInformation } from './transactionalinformation.entity';

export class ApplicationMenu extends TransactionalInformation {
    public MenuId: string;
    public Description: string;
    public Route: string;
    public Module: string;
    public MenuOrder: string;
    public RequiresAuthenication: string;    
}


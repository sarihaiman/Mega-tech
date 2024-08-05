import { Component, Input, input } from '@angular/core';
import { Settlement } from '../../Models/settlement.model';
import { SettlementService } from '../../Services/settlement.service';

@Component({
  selector: 'app-oneSettlement',
  templateUrl: './oneSettlement.component.html',
  styleUrl: './oneSettlement.component.scss'
})
export class oneSettlementComponent {
[x: string]: any;

  constructor(private settlementService: SettlementService) {
  }

  @Input('se') se!:Settlement;
  
}

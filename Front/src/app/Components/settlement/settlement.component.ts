import { Component } from '@angular/core';
import { SettlementService } from '../../Services/settlement.service';
import { Settlement } from '../../Models/settlement.model';

@Component({
  selector: 'app-settlement',
  templateUrl: './settlement.component.html',
  styleUrl: './settlement.component.scss'
})
export class SettlementComponent {

  constructor(private settlementService: SettlementService) {
    settlementService.GetAll().subscribe((res: any) => this.settlementArr = res);
  }

  settlementArr: Settlement[] = [];
  nameS: string = "";
  flag: boolean = true;
  showIndexBegin: number = 0;

  addSettlement() {
    this.settlementService.AddNewSettlement(this.nameS).subscribe(() =>
      this.settlementService.GetAll().subscribe((res: any) => this.settlementArr = res))
    this.nameS = '';
  }

  deleteS(se: any) {
    this.settlementService.DeleteSettlement(se.settlementId).subscribe(() =>
      this.settlementService.GetAll().subscribe((res: any) => this.settlementArr = res))
  }

  nameEdit: string = "";
  edit: Settlement = { settlementId: 0, settlementName: '' };

  up() {
    this.settlementArr.sort((a, b) => {
      const nameA = a.settlementName?.toUpperCase() || '';
      const nameB = b.settlementName?.toUpperCase() || '';
      if (nameA < nameB) {
        return -1;
      }
      if (nameA > nameB) {
        return 1;
      }
      return 0;
    });
  }

  down() {
    this.settlementArr.sort((a, b) => {
      const nameA = a.settlementName?.toUpperCase() || '';
      const nameB = b.settlementName?.toUpperCase() || '';
      if (nameA < nameB) {
        return 1;
      }
      if (nameA > nameB) {
        return -1;
      }
      return 0;
    });
  }

  filteredSettlements: Settlement[] = [];

  right() {
    this.showIndexBegin += 5;
  }

  left() {
    this.showIndexBegin -= 5;
  }

  editIndex: number = -1;

  editS(index: number,settlement: Settlement) {
    this.editIndex = index;
    this.nameEdit=settlement.settlementName!;
  }

  saveEdit(settlement: Settlement) {
    this.editIndex = -1;
    console.log(this.nameEdit);
    this.edit.settlementName = this.nameEdit;
    this.edit.settlementId = settlement.settlementId;
    console.log(this.edit);
    this.settlementService.EditSettlement(this.edit).subscribe(() =>
      this.settlementArr.forEach(element => {
        this.settlementService.GetAll().subscribe((res: any) => this.settlementArr = res)
      })
    )
    this.nameEdit = ""
  }

  transliterationMap: { [key: string]: string } = {
    'a': 'ש',
    'b': 'נ',
    'c': 'ב',
    'd': 'ג',
    'e': 'ק',
    'f': 'כ',
    'g': 'ע',
    'h': 'י',
    'i': 'ן',
    'j': 'ח',
    'k': 'ל',
    'l': 'ך',
    'm': 'צ',
    'n': 'מ',
    'o': 'ם',
    'p': 'פ',
    'r': 'ר',
    's': 'ד',
    't': 'ג',
    'u': 'ו',
    'v': 'ה',
    'x': 'ס',
    'y': 'ט',
    'z': 'ז',
    ',': 'ת',
    '.': 'ץ',
    ';': 'ף',
  };
  
  search(event: Event): void {
    this.settlementService.GetAll().subscribe((res: any) => this.settlementArr = res);
    this.flag = false;
    // הופך לאותיות קטנוץ
    const inputText = this.transliterateInput((event.target as HTMLInputElement).value.toLowerCase());
    if (!this.settlementArr) {
      this.settlementService.GetAll().subscribe((res: any) => {
        this.settlementArr = res;
        this.filterSettlements(inputText);
      });
    } else {
      this.filterSettlements(inputText);
    }
    this.settlementArr=[];
    this.filteredSettlements.forEach((element) => {
      this.settlementArr.push(element)
    })
    console.log(this.settlementArr);
    console.log(this.flag);
    this.flag=true;
    console.log(this.settlementArr);
    console.log(this.flag);
  }
  
  transliterateInput(inputText: string): string {
    return inputText.split('').map(char => this.transliterationMap[char] || char).join('');
  }
  
  filterSettlements(inputText: string): void {
    this.filteredSettlements = this.settlementArr.filter(settlement =>
      settlement.settlementName && this.normalizeText(settlement.settlementName).includes(this.normalizeText(inputText))
    );
  }
  
  normalizeText(text: string): string {
    return text.replace(/[a-zA-Z]/g, (char) => this.transliterationMap[char.toLowerCase()] || char);
  }
  
}

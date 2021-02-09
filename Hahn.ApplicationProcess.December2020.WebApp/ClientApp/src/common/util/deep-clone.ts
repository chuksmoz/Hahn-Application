export class Clone{
  static deepClone(obj) {
    return JSON.parse(JSON.stringify(obj));
  }
    

  static isEqual(obj1, obj2): boolean {
    for (let prop in obj1) {
      if (typeof obj1[prop] === 'object') {
        return this.isEqual(obj1[prop], obj2[prop]);
      }
  
      if (obj1[prop] !== obj2[prop]) {
        return false;
      }
    }
  
    return true;
  }
}

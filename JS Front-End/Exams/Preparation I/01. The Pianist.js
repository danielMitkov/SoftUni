function solve(arr) {
  const n = Number(arr.shift());
  const entriesStrArr = arr.slice(0, n);
  const commands = arr.slice(n);
  const entries = [];
  for (let entry of entriesStrArr) {
    const [piece, composer, key] = entry.split('|');
    entries.push({ piece, composer, key });
  }
  for (let action of commands) {
    if (action === 'Stop') {
      break;
    }
    const tokens = action.split('|');
    const piece = tokens[1];
    if (tokens[0] === 'Add') {
      if (entries.some(x => x.piece === piece)) {
        console.log(`${piece} is already in the collection!`);
        continue;
      }
      const composer = tokens[2];
      const key = tokens[3];
      entries.push({ piece, composer, key });
      console.log(`${piece} by ${composer} in ${key} added to the collection!`);
    }
    if (tokens[0] === 'Remove') {
      const index = entries.findIndex(x => x.piece === piece);
      if (index === -1) {
        console.log(`Invalid operation! ${piece} does not exist in the collection.`);
        continue;
      }
      entries.splice(index, 1);
      console.log(`Successfully removed ${piece}!`);
    }
    if (tokens[0] === 'ChangeKey') {
      const index = entries.findIndex(x => x.piece === piece);
      if (index === -1) {
        console.log(`Invalid operation! ${piece} does not exist in the collection.`);
        continue;
      }
      const key = tokens[2];
      entries[index].key = key;
      console.log(`Changed the key of ${piece} to ${key}!`);
    }
  }
  for (const obj of entries) {
    console.log(`${obj.piece} -> Composer: ${obj.composer}, Key: ${obj.key}`);
  }
}
solve([
  '3',
  'Fur Elise|Beethoven|A Minor',
  'Moonlight Sonata|Beethoven|C# Minor',
  'Clair de Lune|Debussy|C# Minor',
  'Add|Sonata No.2|Chopin|B Minor',
  'Add|Hungarian Rhapsody No.2|Liszt|C# Minor',
  'Add|Fur Elise|Beethoven|C# Minor',
  'Remove|Clair de Lune',
  'ChangeKey|Moonlight Sonata|C# Major',
  'Stop'
]
);

Cube BlockA = new(100, 10, 1, 1000, 100, 100);
Cube BlockB = new(1, 10, 1, 100, 1000, 100);
Cube BlockC = new(1, 1000, 10, 10, 100, 1000);
Cube BlockD = new(1, 1000, 1, 10, 10, 100);

int countIguais = 0;
int countDiferentes = 0;

List<Cube> posCertaBlockA = [];
List<Cube> posCertaBlockB = [];
List<Cube> posCertaBlockC = [];
List<Cube> posCertaBlockD = [];


Cube TurnZRight(Cube Block)
{
    Cube newPos = new(Block.Left, Block.Right, Block.Top, Block.Bottom, Block.Rear, Block.Front);

    return newPos;
}

Cube TurnX(Cube Block)
{
    Cube newPos = new(Block.Top, Block.Bottom, Block.Rear, Block.Front, Block.Left, Block.Right);

    return newPos;
}

Cube TurnY(Cube Block)
{
    Cube newPos = new(Block.Front, Block.Rear, Block.Right, Block.Left, Block.Top, Block.Bottom);

    return newPos;
}


void checkCubes(Cube BlockA, Cube BlockB, Cube BlockC, Cube BlockD)
{
    if (
        (BlockA.Top + BlockB.Top + BlockC.Top + BlockD.Top) == 1111 &&
        (BlockA.Bottom + BlockB.Bottom + BlockC.Bottom + BlockD.Bottom) == 1111 &&
        (BlockA.Rear + BlockB.Rear + BlockC.Rear + BlockD.Rear) == 1111 &&
        (BlockA.Front + BlockB.Front + BlockC.Front + BlockD.Front) == 1111
    ) {
        for (int i = 0; i < posCertaBlockA.Count; i++)
        {
            if (BlockA != posCertaBlockA[i] && BlockB != posCertaBlockB[i] && BlockC != posCertaBlockC[i] && BlockD != posCertaBlockD[i])
            {
                posCertaBlockA.Add(BlockA);
                posCertaBlockB.Add(BlockB);
                posCertaBlockC.Add(BlockC);
                posCertaBlockD.Add(BlockD);
                countDiferentes ++;
                Console.WriteLine($"Um acerto aqui! Count da lista {posCertaBlockA.Count}");
            }
        }
    } else {
        countIguais ++;
    }
}

while (true)
{
    for (int RotBlk1y = 0; RotBlk1y < 4; RotBlk1y++)
    {
        checkCubes(BlockA, BlockB, BlockC, BlockD);

        for (int RotBlk1x = 0; RotBlk1x < 4; RotBlk1x++)
        {
            checkCubes(BlockA, BlockB, BlockC, BlockD);

            for (int RotBlk1z = 0; RotBlk1z < 4; RotBlk1z++)
            {
                checkCubes(BlockA, BlockB, BlockC, BlockD);


                for (int RotBlk2y = 0; RotBlk2y < 4; RotBlk2y++)
                {
                    checkCubes(BlockA, BlockB, BlockC, BlockD);

                    
                    for (int RotBlk2x = 0; RotBlk2x < 4; RotBlk2x++)
                    {
                        checkCubes(BlockA, BlockB, BlockC, BlockD);


                        for (int RotBlk2z = 0; RotBlk2z < 4; RotBlk2z++)
                        {
                            checkCubes(BlockA, BlockB, BlockC, BlockD);
                            

                            for (int RotBlk3y = 0; RotBlk3y < 4; RotBlk3y++)
                            {
                                checkCubes(BlockA, BlockB, BlockC, BlockD);
                            

                                for (int RotBlk3x = 0; RotBlk3x < 4; RotBlk3x++)
                                {
                                    checkCubes(BlockA, BlockB, BlockC, BlockD);
                                    

                                    for (int RotBlk3z = 0; RotBlk3z < 4; RotBlk3z++)
                                    {
                                        checkCubes(BlockA, BlockB, BlockC, BlockD);

                                        for (int RotBlk4y = 0; RotBlk4y < 4; RotBlk4y++)
                                        {
                                            checkCubes(BlockA, BlockB, BlockC, BlockD);
                                            
                                            for (int RotBlk4x = 0; RotBlk4x < 4; RotBlk4x++)
                                            {
                                                checkCubes(BlockA, BlockB, BlockC, BlockD);
                                                
                                                for (int RotBlk4z = 0; RotBlk4z < 4; RotBlk4z++)
                                                {
                                                    checkCubes(BlockA, BlockB, BlockC, BlockD);
                                                    
                                                    BlockD = TurnZRight(BlockD);
                                                }

                                                BlockD = TurnX(BlockD);
                                            }

                                            BlockD = TurnY(BlockD);
                                        }

                                        BlockC = TurnZRight(BlockC);
                                    }

                                    BlockC = TurnX(BlockC);
                                }

                                BlockC = TurnY(BlockC);
                            }

                            BlockB = TurnZRight(BlockB);
                        }

                        BlockB = TurnX(BlockB);
                    }

                    BlockB = TurnY(BlockB);
                }

                BlockA = TurnZRight(BlockA);
            }

            BlockA = TurnX(BlockA);
        } 

        BlockA = TurnY(BlockA);

        checkCubes(BlockA, BlockB, BlockC, BlockD);
    }

    Thread.Sleep(2000);

    Console.WriteLine($"Vezes em que os cubos ficaram com lados iguais: {countIguais}");
    Console.WriteLine($"Vezes em que os cubos ficaram com os lados diferentes: {countDiferentes}");
    Console.WriteLine($"Soma dos resultados: {countIguais + countDiferentes}");

    break;
}
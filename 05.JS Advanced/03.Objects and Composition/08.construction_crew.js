function modifyWorker(worker) {

    if (!worker.dizziness) {
        return worker;
    }

    let neededWater = worker.weight * 0.1 * worker.experience;
    worker.levelOfHydrated += neededWater;

    worker.dizziness = false;

    return worker;
}

modifyWorker({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true });